﻿using System.Collections.Generic;
using FlubuCore.BuildServers.Configurations;
using FlubuCore.BuildServers.Configurations.Models.Jenkins;
using Xunit;

namespace FlubuCore.Tests.BuildServers
{
    public class JenkinsConfigurationSerializerTests
    {
        private JenkinsConfigurationSerializer _writer;

        public JenkinsConfigurationSerializerTests()
        {
            _writer = new JenkinsConfigurationSerializer();
        }

        [Fact]
        public void Pipeline_StagesTest()
        {
            const string expectedPipeLine = @"pipeline {
    stages {
        stage('Build') {
            flubu build
        }

        stage('Test') {
            flubu test
        }

        stage('Package') {
            flubu package
        }

    }

}
";
            var jenkinsPipeline = _writer.Serialize(new JenkinsPipeline
            {
                Stages = new List<Stage>()
                {
                    new Stage
                    {
                        Name = "Build",
                        Steps = new List<string>() { "flubu build" }
                    },
                    new Stage
                    {
                        Name = "Test",
                        Steps = new List<string>() { "flubu test" }
                    },
                    new Stage
                    {
                        Name = "Package",
                        Steps = new List<string>() { "flubu package" }
                    },
                }
            });

            Assert.Equal(expectedPipeLine, jenkinsPipeline);
        }

        [Fact]
        public void Pipeline_StagesWithWorkingDirectoryTest()
        {
            const string expectedPipeLine = @"pipeline {
    stages {
        stage('Build') {
            dir('src') {
                flubu build
            }
        }

        stage('Test') {
            flubu test
        }

        stage('Package') {
            dir('src') {
                flubu package
            }
        }

    }

}
";
            var jenkinsPipeline = _writer.Serialize(new JenkinsPipeline
            {
                Stages = new List<Stage>()
                {
                    new Stage
                    {
                        Name = "Build",
                        WorkingDirectory = "src",
                        Steps = new List<string>() { "flubu build" }
                    },
                    new Stage
                    {
                        Name = "Test",
                        Steps = new List<string>() { "flubu test" }
                    },
                    new Stage
                    {
                        Name = "Package",
                        WorkingDirectory = "src",
                        Steps = new List<string>() { "flubu package" }
                    },
                }
            });

            Assert.Equal(expectedPipeLine, jenkinsPipeline);
        }

        [Fact]
        public void Pipeline_OptionsTest()
        {
            const string expectedPipeLine = @"pipeline {
    options {
        disableConcurrentBuilds()
        checkoutToSubdirectory('subfolder')
        retry(20)
    }

}
";
            var jenkinsPipeline = _writer.Serialize(new JenkinsPipeline
            {
                Options = new JenkinsOptionsDirective()
                {
                    CheckoutToSubDirectory = "subfolder",
                    Retry = 20,
                    DisableConcurrentBuilds = true
                }
            });

            Assert.Equal(expectedPipeLine, jenkinsPipeline);
        }

        [Fact]
        public void Pipeline_PostTest()
        {
            const string expectedPipeLine = @"pipeline {
    post {
        always {
            Some post step always
        }
        failure {
            Some post step failure
        }
    }
}
";
            var jenkinsPipeline = _writer.Serialize(new JenkinsPipeline
            {
                Post = new List<JenkinsPost>()
                {
                    new JenkinsPost()
                    {
                        Condition = JenkinsPostConditions.Always,
                        Steps = new List<string>() { "Some post step always" }
                    },
                    new JenkinsPost()
                    {
                        Condition = JenkinsPostConditions.Failure,
                        Steps = new List<string>() { "Some post step failure" }
                    },
                }
            });

            Assert.Equal(expectedPipeLine, jenkinsPipeline);
        }

        [Fact]
        public void Pipeline_SimpleAllTest()
        {
            const string expectedPipeLine = @"pipeline {
    options {
        timestamps()
    }

    stages {
        stage('Build') {
            dir('src') {
                flubu build
            }
        }

    }

    post {
        always {
            Some post step always
        }
    }
}
";

            var jenkinsPipeline = _writer.Serialize(new JenkinsPipeline
            {
                Options = new JenkinsOptionsDirective()
                {
                   TimeStamps = true
                },

                Stages = new List<Stage>()
                {
                    new Stage
                    {
                        Name = "Build",
                        WorkingDirectory = "src",
                        Steps = new List<string>() { "flubu build" }
                    },
                },

                Post = new List<JenkinsPost>()
                {
                    new JenkinsPost()
                    {
                        Condition = JenkinsPostConditions.Always,
                        Steps = new List<string>() { "Some post step always" }
                    },
                }
            });

            Assert.Equal(expectedPipeLine, jenkinsPipeline);
        }
    }
}