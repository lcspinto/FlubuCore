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

namespace FlubuCore.Tasks.Docker.Image
{
    public partial class DockerImageRmTask : ExternalProcessTaskBase<int, DockerImageRmTask>
    {
        private string[] _image;


        public DockerImageRmTask(params string[] image)
        {
            ExecutablePath = "docker";
            WithArguments("image rm");
            _image = image;
        }

        protected override string Description { get; set; }

        /// <summary>
        /// Force removal of the image
        /// </summary>
        [ArgKey("--force")]
        public DockerImageRmTask Force()
        {
            WithArgumentsKeyFromAttribute();
            return this;
        }

        /// <summary>
        /// Do not delete untagged parents
        /// </summary>
        [ArgKey("--no-prune")]
        public DockerImageRmTask NoPrune()
        {
            WithArgumentsKeyFromAttribute();
            return this;
        }

        protected override int DoExecute(ITaskContextInternal context)
        {
            WithArguments(_image);

            return base.DoExecute(context);
        }
    }
}