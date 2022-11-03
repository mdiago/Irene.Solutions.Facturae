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

using System.Net;
using System.Text;

namespace Irene.Solutions.Facturae.Business.Net
{
    /// <summary>
    /// Representa una petición http al API de Nordigen.
    /// </summary>
    public class IreneSolutionsRequest
    {

        #region Public Members

        /// <summary>
        /// Url completa de la petición.
        /// </summary>
        public virtual string Url { get; set; }

        /// <summary>
        /// Método de la petición. POST es el método
        /// por defecto.
        /// </summary>
        public virtual string Method { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="url">Url de la petición.</param>
        /// <param name="method">Método de la petición.</param>
        /// <param name="args">Argumento para la Url.</param>
        public IreneSolutionsRequest(string url, string method = WebRequestMethods.Http.Post, params string[] args)
        {

            Url = string.Format(url, args);
            Method = method;

        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Obtiene como cadena de texto el cuerpo de la
        /// petición http.
        /// </summary>
        /// <param name="json">JSON de entrada para la petición.</param>
        /// <returns>Cadena de texto el cuerpo de la
        /// petición http</returns>
        public string GetResponse(string json = null)
        {

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
            request.Method = Method;

            if (Method == WebRequestMethods.Http.Post)
            {
                request.ContentType = "application/x-www-form-urlencoded";
                SetActionRequestPostData(request, json);
            }

            request.Accept = "*/*";

            return GetActionRequestResult(request);

        }

        /// <summary>
        /// Compone el request incluyendo los datos
        /// para realizar el post al servidor.
        /// </summary>
        /// <param name="request">Petición a enviar al servidor.</param>
        /// <param name="json">Objeto en formato json a enviar.</param>
        public void SetActionRequestPostData(HttpWebRequest request, string json)
        {

            byte[] jsonBuffer = Encoding.UTF8.GetBytes(json);

            request.ContentLength = jsonBuffer.Length;
            using (var dataStream = request.GetRequestStream())
            {
                dataStream.Write(jsonBuffer, 0, jsonBuffer.Length);
                dataStream.Close();
            }

        }

        /// <summary>
        /// Envía la petición al servidor y recupera el resultado.
        /// </summary>
        /// <param name="request">Petición a enviar.</param>
        /// <returns>Resultado de una petición JsonToJson.</returns>
        public string GetActionRequestResult(HttpWebRequest request)
        {

            HttpWebResponse response = null;

            response = (HttpWebResponse)request.GetResponse();

            var encoding = Encoding.UTF8;
            string result = "";
            using (var reader = new System.IO.StreamReader(
                        response.GetResponseStream(), encoding))
            {
                result = reader.ReadToEnd();
            }

            response.Close();

            return result;

        }

        #endregion

    }

}
