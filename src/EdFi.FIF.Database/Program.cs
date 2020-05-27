// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using DbUp;
using DbUp.Engine;
using System;
using System.Diagnostics;
using System.Reflection;

namespace EdFi.FIF.Database
{
    class Program
    {
        static int Main(string[] args)
        {
            if (args.Length == 0)
            {
                throw new ArgumentException("Please provide a database connection string.");
            }

            string connectionString = args[0];

            EnsureDatabase.For.SqlDatabase(connectionString);

            UpgradeEngine upgrader =
                DeployChanges.To
                    .SqlDatabase(connectionString)
                    .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                    .LogToConsole()
                    .Build();

            DatabaseUpgradeResult result = upgrader.PerformUpgrade();

            if (!result.Successful)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(result.Error);
                Console.ResetColor();
                if (Debugger.IsAttached)
                {
                    Console.ReadLine();
                }
                return -1;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Success!");
            Console.ResetColor();
            return 0;
        }
    }
}
