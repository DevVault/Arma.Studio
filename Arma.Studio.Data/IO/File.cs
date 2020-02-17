﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arma.Studio.Data.IO
{
    public class File : FileFolderBase
    {
        public PBO PBO
        {
            get
            {
                FileFolderBase ffb = this;
                while (ffb != null && !(ffb is PBO))
                {
                    ffb = ffb.Parent;
                }
                return ffb as PBO;
            }
        }
        public string Extension => System.IO.Path.GetExtension(this.Name);
        protected override void OnNameChanged()
        {
            this.RaisePropertyChanged(nameof(this.Extension));
        }

        public string PhysicalPath
        {
            get
            {
                // ToDo: Introduce virtual paths and change this to always return the physical one
                return this.FullPath;
            }
        }
    }
}
