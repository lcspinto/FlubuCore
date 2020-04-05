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

namespace FlubuCore.Tasks.Docker.Secret
{
    public partial class DockerSecretLsTask : ExternalProcessTaskBase<int, DockerSecretLsTask>
    {
        public DockerSecretLsTask()
        {
            ExecutablePath = "docker";
            WithArguments("secret ls");
        }

        protected override string Description { get; set; }

        /// <summary>
        /// Filter output based on conditions provided
        /// </summary>
        [ArgKey("--filter")]
        public DockerSecretLsTask Filter(string filter)
        {
            WithArgumentsKeyFromAttribute(filter.ToString());
            return this;
        }

        /// <summary>
        /// Pretty-print secrets using a Go template
        /// </summary>
        [ArgKey("--format")]
        public DockerSecretLsTask Format(string format)
        {
            WithArgumentsKeyFromAttribute(format.ToString());
            return this;
        }

        /// <summary>
        /// Only display IDs
        /// </summary>
        [ArgKey("--quiet")]
        public DockerSecretLsTask Quiet()
        {
            WithArgumentsKeyFromAttribute();
            return this;
        }

        protected override int DoExecute(ITaskContextInternal context)
        {
            return base.DoExecute(context);
        }
    }
}