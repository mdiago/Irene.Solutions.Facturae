/*
    This file is part of the Irene.Solutions.Facturae (R) project.
    Copyright (c) 2020-2021 Irene Solutions SL
    Authors: Irene Solutions SL.

    This program is free software; you can redistribute it and/or modify
    it under the terms of the GNU Affero General Public License version 3
    as published by the Free Software Foundation with the addition of the
    following permission added to Section 15 as permitted in Section 7(a):
    FOR ANY PART OF THE COVERED WORK IN WHICH THE COPYRIGHT IS OWNED BY
    IRENE SOLUTIONS SL. IRENE SOLUTIONS SL DISCLAIMS THE WARRANTY OF NON INFRINGEMENT
    OF THIRD PARTY RIGHTS
    
    This program is distributed in the hope that it will be useful, but
    WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY
    or FITNESS FOR A PARTICULAR PURPOSE.
    See the GNU Affero General Public License for more details.
    You should have received a copy of the GNU Affero General Public License
    along with this program; if not, see http://www.gnu.org/licenses or write to
    the Free Software Foundation, Inc., 51 Franklin Street, Fifth Floor,
    Boston, MA, 02110-1301 USA, or download the license from the following URL:
        http://www.irenesolutions.com/terms-of-use.pdf
    
    The interactive user interfaces in modified source and object code versions
    of this program must display Appropriate Legal Notices, as required under
    Section 5 of the GNU Affero General Public License.
    
    You can be released from the requirements of the license by purchasing
    a commercial license. Buying such a license is mandatory as soon as you
    develop commercial activities involving the Irene.Solutions.Facturae software without
    disclosing the source code of your own applications.
    These activities include: offering paid services to customers as an ASP,
    serving Irene.Solutions.Facturae services on the fly in a web application, 
    shipping Irene.Solutions.Facturae with a closed source product.
    
    For more information, please contact Irene Solutions SL. at this
    address: info@irenesolutions.com
 */


using Irene.Solutions.Facturae.Business.Json.Serializer;
using System;
using System.Collections;
using System.Reflection;
using System.Text;

namespace Irene.Solutions.Facturae.Business.Json
{

    /// <summary>
    /// Clase serializable en JSON.
    /// </summary>
    public class JsonSerializable
    {

        /// <summary>
        /// Representación de la clase en formato
        /// JSON.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {

            var stringBuilder = new StringBuilder();

            foreach (var pInf in GetType().GetProperties()) 
            {

                var value = pInf.GetValue(this);

                if (value == null)
                    continue;

                var iList = value as IList;

                if (iList == null) 
                {

                    AppendJson(stringBuilder, pInf, value);
                    continue;

                } 
                else 
                {

                    string[] jsons = new string[iList.Count];

                    for (int i = 0; i < iList.Count; i++) 
                    {

                        var item = iList[i];

                        if (typeof(JsonSerializable).IsAssignableFrom(item.GetType()))
                            jsons[i] = $"{item}";
                        else 
                            jsons[i] = new JsonSerializer("", item).ToJson();

                    }

                    AppendTokenJson(stringBuilder, $"{pInf.Name}:[{string.Join(",", jsons)}]");

                }               
                    
            }

            return $"{{{stringBuilder.ToString()}}}";

        }

        private void AppendTokenJson(StringBuilder stringBuilder, string keyValueText) 
        {

            string json = (stringBuilder.Length == 0) ? "" : ",";
            json += keyValueText;
            stringBuilder.Append(json);

        }


        private void AppendJson(StringBuilder stringBuilder, PropertyInfo pInf, object value) 
        {

            if (typeof(JsonSerializable).IsAssignableFrom(pInf.PropertyType))
            {
                
                AppendTokenJson(stringBuilder, $"\"{pInf.Name}\"={{{this}}}");

            }
            else
            {
                
                var keyValueJson = new JsonSerializer(pInf, value).ToJson();

                if(keyValueJson != null)
                    AppendTokenJson(stringBuilder, new JsonSerializer(pInf, value).ToJson());

            }

        }

       

    }

}
