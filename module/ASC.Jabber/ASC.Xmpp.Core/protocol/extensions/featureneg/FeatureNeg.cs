// // --------------------------------------------------------------------------------------------------------------------
// // <copyright company="Ascensio System Limited" file="FeatureNeg.cs">
// //   
// // </copyright>
// // <summary>
// //   (c) Copyright Ascensio System Limited 2008-2012
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------

using ASC.Xmpp.Core.protocol.x.data;
using ASC.Xmpp.Core.utils.Xml.Dom;

namespace ASC.Xmpp.Core.protocol.extensions.featureneg
{
    /// <summary>
    ///   JEP-0020: Feature Negotiation This JEP defines a A protocol that enables two Jabber entities to mutually negotiate feature options.
    /// </summary>
    public class FeatureNeg : Element
    {
        /*
		<iq type='get'
			from='romeo@montague.net/orchard'
			to='juliet@capulet.com/balcony'
			id='neg1'>
			<feature xmlns='http://jabber.org/protocol/feature-neg'>
				<x xmlns='jabber:x:data' type='form'>
				<field type='list-single' var='places-to-meet'>
					<option><value>Lover's Lane</value></option>
					<option><value>Secret Grotto</value></option>
					<option><value>Verona Park</value></option>
				</field>
				<field type='list-single' var='times-to-meet'>
					<option><value>22:00</value></option>
					<option><value>22:30</value></option>
					<option><value>23:00</value></option>
					<option><value>23:30</value></option>
				</field>
				</x>
			</feature>
		</iq>
		*/

        public FeatureNeg()
        {
            TagName = "feature";
            Namespace = Uri.FEATURE_NEG;
        }

        /// <summary>
        ///   data form of type "form" which defines the available options for one or more features. Each feature is represented as an x-data "field", which MUST be of type "list-single".
        /// </summary>
        public Data Data
        {
            get
            {
                Element data = SelectSingleElement(typeof (Data));
                if (data != null)
                    return data as Data;
                else
                    return null;
            }
            set
            {
                if (HasTag(typeof (Data)))
                    RemoveTag(typeof (Data));

                AddChild(value);
            }
        }
    }
}