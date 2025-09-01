using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace Guan.Properties
{
    [GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [CompilerGenerated]
    [DebuggerNonUserCode]
    internal class Resources
    {
        internal Resources()
        {
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        internal static ResourceManager ResourceManager
        {
            get
            {
                if (object.ReferenceEquals(Resources.resourceMan, null))
                {
                    ResourceManager resourceManager = new ResourceManager("Guan.Properties.Resources", typeof(Resources).Assembly);
                    Resources.resourceMan = resourceManager;
                }
                return Resources.resourceMan;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        internal static CultureInfo Culture
        {
            get
            {
                return Resources.resourceCulture;
            }
            set
            {
                Resources.resourceCulture = value;
            }
        }

        internal static string Head
        {
            get
            {
                return Resources.ResourceManager.GetString("Head", Resources.resourceCulture);
            }
        }

        internal static string Instructions
        {
            get
            {
                return Resources.ResourceManager.GetString("Instructions", Resources.resourceCulture);
            }
        }

        internal static string Instructions_en
        {
            get
            {
                return Resources.ResourceManager.GetString("Instructions_en", Resources.resourceCulture);
            }
        }

        internal static string Tail
        {
            get
            {
                return Resources.ResourceManager.GetString("Tail", Resources.resourceCulture);
            }
        }

        internal static Icon 光立方
        {
            get
            {
                object @object = Resources.ResourceManager.GetObject("光立方", Resources.resourceCulture);
                return (Icon)@object;
            }
        }

        private static ResourceManager resourceMan;

        private static CultureInfo resourceCulture;
    }
}
