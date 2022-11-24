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

using Irene.Solutions.Facturae.Business.Face;
using Irene.Solutions.Facturae.Business.Invoices;
using Irene.Solutions.Facturae.Business.Net;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Irene.Solutions.Facturae
{

    /// <summary>
    /// Esta clase se encarga de las operaciones necesarias para
    /// la generación y firma de facturae. También permite realizar
    /// envíos directamente a FACe.
    /// </summary>
    public class FacturaeManager
    {

        #region Variables Privadas de Instancia

        /// <summary>
        /// Key de acceso al API de Irene Solutions
        /// para facturae.
        /// </summary>
        readonly string _ServiceKey;

        /// <summary>
        /// Punto de entrada API REST.
        /// </summary>
        readonly string _UrlRoot = "https://facturae.irenesolutions.com:8050/Kivu/";

        #endregion

        #region Construtores de Instancia

        /// <summary>
        /// Construye una nueva instancia de FacturaeManager.
        /// </summary>
        /// <param name="serviceKey">Key de acceso al API de Irene Solutions
        /// para facturae.</param>
        public FacturaeManager(string serviceKey) 
        {

            _ServiceKey = serviceKey;

        }

        #endregion

        #region Métodos Privados de Instancia

        /// <summary>
        /// Crea el texto xml facturae sin firmar por defecto
        /// (con el parametro action como 'Get' por defecto)
        /// o firmada si se pasa el parámetro action como 
        /// 'GetSigned', a partir de una instancia de Invoice.
        /// </summary>
        /// <param name="invoice">Instancia de Invoice.</param>
        /// <param name="action">
        /// <para>'Get': facturae sin firmar.</para>
        /// <para>'GetSigned': facturae firmada.</para>
        /// </param>
        /// <returns>Facturae obtenido de la instancia de Invoice.</returns>
        /// <returns></returns>
        private string Create(Invoice invoice, string action = "Get") 
        {

            invoice.ServiceKey = _ServiceKey;
            var json = $"{invoice}";

            var request = new IreneSolutionsRequest(
                $"{_UrlRoot}Isolutions/Facturae/Facturae/{action}");

            var response = request.GetResponse(json);

            var resultCode = GetResponseKeyValue(response, "ResultCode");
            var resultMessage = GetResponseKeyValue(response, "ResultMessage");

            if (resultCode != "0")
                throw new Exception(resultMessage);

            var facturaeBase64 = GetResponseKeyValue(response, "Return");
            var facturaeUTF8 = Convert.FromBase64String(facturaeBase64);

            return Encoding.UTF8.GetString(facturaeUTF8);

        }

        #endregion

        #region Métodos Públicos Estáticos

        /// <summary>
        /// Recupera el valor de una clave en
        /// el resultado de la petición.
        /// </summary>
        /// <param name="response">Texto de la respuesta.</param>
        /// <param name="key">Clave del valor a recuperar.</param>
        /// <returns>Código de resultado.</returns>
        public static string GetResponseKeyValue(string response, string key)
        {

            var pattern = "(\"|'){0,1}" + key + "(\"|'){0,1}" +
                @"\s*:\s*" + "\"\"";

            if (Regex.IsMatch(response, pattern)) // Valor es cadena vacía
                return "";

            pattern = "(?<=(\"|'){0,1}" + key + "(\"|'){0,1}" +
                @"\s*:\s*" + "\"*)[^\"]" + @"[\s\S]*?" + "(?=(\"|'){0,1}(}|,))";

            var value = Regex.Match(response, pattern).Value;

            return value;

        }

        #endregion

        #region Métodos Públicos de Instancia

        /// <summary>
        /// Crea el texto xml facturae sin firmar a partir
        /// de una instancia de Invoice.
        /// </summary>
        /// <param name="invoice">Instancia de Invoice.</param>
        /// <returns>Facturae obtenido de la instancia de Invoice.</returns>
        public string Create(Invoice invoice) 
        {

            return Create(invoice, "Get");

        }

        /// <summary>
        /// Crea el texto xml facturae firmada a partir
        /// de una instancia de Invoice.
        /// </summary>
        /// <param name="invoice">Instancia de Invoice.</param>
        /// <returns>Facturae obtenido de la instancia de Invoice.</returns>
        public string CreateSigned(Invoice invoice)
        {

            return Create(invoice, "GetSigned");

        }

        /// <summary>
        /// Devuelve una lista con los centros administrativos
        /// del organismo al que pertenece el NIF facilitado como
        /// parmatro de entrada.
        /// </summary>
        /// <param name="taxID">NIF del organismo del cual se quieren
        /// obtener los centros administrativos.</param>
        /// <returns>Lista de centros administrativos encontrados
        /// o null.</returns>
        public List<InvoiceAdministrativeCentre> GetAdministrativeCentres(string taxID)
        {

            var json = $"{{\"ServiceKey\":\"{_ServiceKey}\",\"Offset\":0,\"Count\":1" +
                $",\"OrderClause\":\"ORDER BY Created DESC\",\"Filters\":" +
                $"[{{\"FieldName\":\"TaxID\",\"Operator\":\"LIKE\",\"Value\":\"'{taxID}'\"}}]}}";

            var request = new IreneSolutionsRequest(
                $"{_UrlRoot}Isolutions/Facturae/FaceRelations/GetFilteredList");

            var response = request.GetResponse(json);

            var resultCode = GetResponseKeyValue(response, "ResultCode");
            var resultMessage = GetResponseKeyValue(response, "ResultMessage");

            if (resultCode != "0")
                throw new Exception(resultMessage);

            var jsonItems = Regex.Match(response, @"(?<=" + "\"Items\":" + @"\[)[^\]]+");

            if (jsonItems != null)
            {

                var result = new List<InvoiceAdministrativeCentre>();
                var centreCode = GetResponseKeyValue(response, "AccountingOffice");

                if (!string.IsNullOrEmpty(centreCode))
                    result.Add(new InvoiceAdministrativeCentre()
                    {
                        CentreCode = centreCode,
                        CentreDescription = "Oficina Contable"
                    });

                centreCode = GetResponseKeyValue(response, "ManagingOffice");

                if (!string.IsNullOrEmpty(centreCode))
                    result.Add(new InvoiceAdministrativeCentre()
                    {
                        CentreCode = centreCode,
                        CentreDescription = "Organo Gestor"
                    });

                centreCode = GetResponseKeyValue(response, "Administration");

                if (!string.IsNullOrEmpty(centreCode))
                    result.Add(new InvoiceAdministrativeCentre()
                    {
                        CentreCode = centreCode,
                        CentreDescription = "Unidad Tramitadora"
                    });

                return result;

            }

            return null;

        }

        /// <summary>
        /// Envía una factura a FACe.
        /// </summary>
        /// <param name="face">Objeto Face a enviar.</param>
        /// <returns>Texto respuesta FACe.</returns>
        public string SendFace(Face face)
        {

            face.ServiceKey = _ServiceKey;
            var json = $"{face}";

            var request = new IreneSolutionsRequest(
                $"{_UrlRoot}Isolutions/Facturae/FaceFacturae/Send");

            var response = request.GetResponse(json);

            var resultCode = GetResponseKeyValue(response, "ResultCode");
            var resultMessage = GetResponseKeyValue(response, "ResultMessage");

            if (resultCode != "0")
                throw new Exception(resultMessage);

            var responseFACE = GetResponseKeyValue(response, "Return");

            return responseFACE;

        }

        #endregion

    }

}
