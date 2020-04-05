//-----------------------------------------------------------------------
// <auto-generated />
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;
using FlubuCore.Context;
using FlubuCore.Tasks;
using FlubuCore.Tasks.Attributes;
using FlubuCore.Tasks.Process;

namespace FlubuCore.Tasks.Docker.Container
{
    public partial class DockerContainerStartTask : ExternalProcessTaskBase<int, DockerContainerStartTask>
    {
        private string[] _container;


        public DockerContainerStartTask(params string[] container)
        {
            ExecutablePath = "docker";
            WithArguments("container start");
            _container = container;
        }

        protected override string Description { get; set; }

        /// <summary>
        /// Attach STDOUT/STDERR and forward signals
        /// </summary>
        [ArgKey("--attach")]
        public DockerContainerStartTask Attach()
        {
            WithArgumentsKeyFromAttribute();
            return this;
        }

        /// <summary>
        /// Restore from this checkpoint
        /// </summary>
        [ArgKey("--checkpoint")]
        public DockerContainerStartTask Checkpoint(string checkpoint)
        {
            WithArgumentsKeyFromAttribute(checkpoint.ToString());
            return this;
        }

        /// <summary>
        /// Use a custom checkpoint storage directory
        /// </summary>
        [ArgKey("--checkpoint-dir")]
        public DockerContainerStartTask CheckpointDir(string checkpointDir)
        {
            WithArgumentsKeyFromAttribute(checkpointDir.ToString());
            return this;
        }

        /// <summary>
        /// Override the key sequence for detaching a container
        /// </summary>
        [ArgKey("--detach-keys")]
        public DockerContainerStartTask DetachKeys(string detachKeys)
        {
            WithArgumentsKeyFromAttribute(detachKeys.ToString());
            return this;
        }

        /// <summary>
        /// Attach container's STDIN
        /// </summary>
        [ArgKey("--interactive")]
        public DockerContainerStartTask Interactive()
        {
            WithArgumentsKeyFromAttribute();
            return this;
        }

        protected override int DoExecute(ITaskContextInternal context)
        {
            WithArguments(_container);

            return base.DoExecute(context);
        }
    }
}