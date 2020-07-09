// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
const globby = require('globby');
const execa = require('execa');
const perf = require('execution-time')();
const colors = require('colors/safe');

function runSqlLintOnFile(file, writer) {
    let numFailures = 0;

    perf.start(file);
    writer.testStarted(file);

    try {
        execa.sync(`npx sql-lint --driver="postgres" --format json ${file}`);
    } catch (err) {
        const {error, line} = JSON.parse(err.stdout);
        writer.testFailure(file, error, line);
        numFailures = 1;
    }
    const {time} = perf.stop(file);
    writer.testFinished(file, time);

    return numFailures;
}

const cliWriter = {
    // Default writer
    testSuiteStarted: (testSuiteName) => console.log(`sql-lint started`),  // TODO: write the sql-lint version
    testStarted: (testName) => null,
    testFailure: (testName, msg, line) => {
        console.log(colors.red(' X'), testName);
        console.log(colors.red(` Error Message: ${msg}`));
        console.log(colors.red(` Stack Trace: line ${line}`));
    },
    testFinished: (testName, duration) => null,
    testSuiteFinished: (testSuiteName, duration, numTests, numFailures) => {
        if (numFailures) {
            console.log(colors.red('Test Run Failed.'));
        }
        console.log(`Total tests: ${numTests}`);
        console.log(colors.green(`     Passed: ${numTests-numFailures}`));
        console.log(colors.red(`     Failed: ${numFailures}`));
        console.log(` Total time: ${duration/1000} seconds`);
    }
};

const teamCityWriter = {
    // Will be used when running in TeamCity
    testSuiteStarted: (testSuiteName) => console.log(`##teamcity[testSuiteStarted name='${testSuiteName}']`),
    testStarted: (testName) => console.log(`##teamcity[testStarted name='${testName}']`),
    testFailure: (testName, msg, line) => console.log(`##teamcity[testFailed name='${testName}' message='${msg}' details='failure on line ${line}']`),
    testFinished: (testName, duration) => console.log(`##teamcity[testFinished name='${testName}' duration='${duration}']`),
    testSuiteFinished: (testSuiteName, duration, numTests, numFailures) => console.log(`##teamcity[testSuiteFinished name='${testSuiteName}' duration='${duration}']`),
};

(async () => {
    let writer = cliWriter;
    if (process.env.CI==="true" && process.env.TEAMCITY_VERSION) {
        writer = teamCityWriter;
    }

    const testSuiteName = "edfi.fif.database";
    writer.testSuiteStarted(testSuiteName);

    perf.start(testSuiteName);

    const paths = await globby(['migrations/**/*.sql']);

    let numFailures = 0;

    paths.forEach((item, index) => {
        numFailures += runSqlLintOnFile(item, writer)
    });

    const {time} = perf.stop(testSuiteName);
    writer.testSuiteFinished(testSuiteName, time, paths.length, numFailures);
})();
