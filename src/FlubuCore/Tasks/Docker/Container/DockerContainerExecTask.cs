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
    public partial class DockerContainerExecTask : ExternalProcessTaskBase<int, DockerContainerExecTask>
    {
        private string _container;
        private string _command;
        private string[] _arg;


        public DockerContainerExecTask(string container, string command, params string[] arg)
        {
            ExecutablePath = "docker";
            WithArguments("container exec");
            _container = container;
            _command = command;
            _arg = arg;
        }

        protected override string Description { get; set; }

        /// <summary>
        /// Detached mode: run command in the background
        /// </summary>
        [ArgKey("--detach")]
        public DockerContainerExecTask Detach()
        {
            WithArgumentsKeyFromAttribute();
            return this;
        }

        /// <summary>
        /// Override the key sequence for detaching a container
        /// </summary>
        [ArgKey("--detach-keys")]
        public DockerContainerExecTask DetachKeys(string detachKeys)
        {
            WithArgumentsKeyFromAttribute(detachKeys.ToString());
            return this;
        }

        /// <summary>
        /// Set environment variables
        /// </summary>
        [ArgKey("--env")]
        public DockerContainerExecTask Env(string env)
        {
            WithArgumentsKeyFromAttribute(env.ToString());
            return this;
        }

        /// <summary>
        /// Keep STDIN open even if not attached
        /// </summary>
        [ArgKey("--interactive")]
        public DockerContainerExecTask Interactive()
        {
            WithArgumentsKeyFromAttribute();
            return this;
        }

        /// <summary>
        /// Give extended privileges to the command
        /// </summary>
        [ArgKey("--privileged")]
        public DockerContainerExecTask Privileged()
        {
            WithArgumentsKeyFromAttribute();
            return this;
        }

        /// <summary>
        /// Allocate a pseudo-TTY
        /// </summary>
        [ArgKey("--tty")]
        public DockerContainerExecTask Tty()
        {
            WithArgumentsKeyFromAttribute();
            return this;
        }

        /// <summary>
        /// Username or UID (format: <name|uid>[:<group|gid>])
        /// </summary>
        [ArgKey("--user")]
        public DockerContainerExecTask User(string user)
        {
            WithArgumentsKeyFromAttribute(user.ToString());
            return this;
        }

        /// <summary>
        /// Working directory inside the container
        /// </summary>
        [ArgKey("--workdir")]
        public DockerContainerExecTask Workdir(string workdir)
        {
            WithArgumentsKeyFromAttribute(workdir.ToString());
            return this;
        }

        protected override int DoExecute(ITaskContextInternal context)
        {
            WithArguments(_container);
            WithArguments(_command);
            WithArguments(_arg);

            return base.DoExecute(context);
        }
    }
}