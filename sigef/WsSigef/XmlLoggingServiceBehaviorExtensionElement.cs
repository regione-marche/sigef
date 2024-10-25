using System;
using System.Configuration;
using System.ServiceModel.Configuration;

namespace WsSigef
{
    public class XmlLoggingServiceBehaviorExtensionElement: BehaviorExtensionElement
    {
        public override Type BehaviorType => typeof(XmlLoggingServiceBehavior);

        protected override object CreateBehavior()
        {
            return new XmlLoggingServiceBehavior();
        }
    }
}