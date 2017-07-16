﻿using CSharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blending
{
    /// <summary>
    /// 
    /// </summary>
    class BlendingGroupRenderer : RendererBase, IRenderable
    {
        private BlendState blending;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="dest"></param>
        public BlendingGroupRenderer(BlendingSourceFactor source, BlendingDestinationFactor dest)
        {
            this.blending = new BlendState(source, dest);
        }

        #region IRenderable 成员

        private ThreeFlags enableRendering = ThreeFlags.BeforeChildren | ThreeFlags.Children | ThreeFlags.AfterChildren;

        /// <summary>
        /// 
        /// </summary>
        public ThreeFlags EnableRendering
        {
            get { return enableRendering; }
            set { enableRendering = value; }
        }

        public void RenderBeforeChildren(RenderEventArgs arg)
        {
            this.blending.On();
        }

        public void RenderAfterChildren(RenderEventArgs arg)
        {
            this.blending.Off();
        }

        #endregion
    }
}
