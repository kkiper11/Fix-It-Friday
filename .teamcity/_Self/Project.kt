// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

package _self

import jetbrains.buildServer.configs.kotlin.v2019_2.*

object FixItFridayProject : Project({
    description = "Projects Owned by the Analytics Team"

    params {
        param("build.feature.freeDiskSpace", "2gb")
        param("git.branch.default", "development")
        param("git.branch.specification", """
            refs/heads/(*)
            refs/(pull/*)/head
        """.trimIndent())
        param("octopus.deploy.timeout", "00:45:00")
        param("octopus.release.environment", "Integration")
    }

    subProject(ui.UIProject)
    subProject(api.APIProject)
    subProject(angular.AngularProject)

    template(_self.templates.BuildAndTestTemplate)
    template(_self.templates.PullRequestTemplate)

})
