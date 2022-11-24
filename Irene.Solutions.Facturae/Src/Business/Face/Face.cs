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

using Irene.Solutions.Facturae.Business.Json;
using System.Collections.Generic;

namespace Irene.Solutions.Facturae.Business.Face
{

    /// <summary>
    /// Representa un envío a FACe.
    /// </summary>
    public class Face : JsonSerializable
    {

        #region Variables Privadas de Instancia

        /// <summary>
        /// Anexos para FACe.
        /// </summary>
        List<FaceAttachment> _FaceAttachments;

        #endregion

        #region Construtores de Instancia

        /// <summary>
        /// Constructor.
        /// </summary>
        public Face()
        {

            _FaceAttachments = new List<FaceAttachment>();

        }

        #endregion

        #region Métodos Privados de Instancia

        /// <summary>
        /// Devuelve una lista con los nombres de
        /// archivo de los anexos.
        /// </summary>
        /// <returns>Lista con los nombres de
        /// archivo de los anexos.</returns>
        private List<string> GetAttachmentsNames()
        {

            var result = new List<string>();

            for (int a = 0; a < _FaceAttachments.Count; a++)
                result.Add(_FaceAttachments[a].Name);

            return result;
        }

        /// <summary>
        /// Devuelve una lista con los tipos mime de
        /// archivo de los anexos.
        /// </summary>
        /// <returns>Lista con los nombres de
        /// archivo de los anexos.</returns>
        private List<string> GetAttachmentsMimes()
        {

            var result = new List<string>();

            for (int a = 0; a < _FaceAttachments.Count; a++)
                result.Add(_FaceAttachments[a].MimeType);

            return result;
        }

        /// <summary>
        /// Devuelve una lista con los datos binarios de
        /// archivo de los anexos.
        /// </summary>
        /// <returns>Lista con los nombres de
        /// archivo de los anexos.</returns>
        private List<byte[]> GetAttachmentsBytes()
        {

            var result = new List<byte[]>();

            for (int a = 0; a < _FaceAttachments.Count; a++)
                result.Add(_FaceAttachments[a].Bytes);

            return result;
        }

        #endregion

        #region Propiedades Públicas de Instancia

        /// <summary>
        /// ServiceKey del API.
        /// </summary>        
        public string ServiceKey { get; internal set; }

        /// <summary>
        /// ServiceKey del API.
        /// </summary>        
        public string InvoiceID { get; set; }

        /// <summary>
        /// ServiceKey del API.
        /// </summary>        
        public string Mail { get; set; }

        /// <summary>
        /// Datos binarios del archivo del xml de facturae
        /// firmado a enviar.
        /// </summary>
        public byte[] Bytes { get; set; }

        /// <summary>
        /// Nombres de archivo de los anexos.
        /// </summary>
        public List<string> AttachmentsNames => GetAttachmentsNames();

        /// <summary>
        /// Tipos mime de archivo de los anexos.
        /// </summary>
        public List<string> AttachmentsMimes => GetAttachmentsMimes();

        /// <summary>
        /// Datos binarios de archivo de los anexos.
        /// </summary>
        public List<byte[]> AttachmentsBytes => GetAttachmentsBytes();

        #endregion

        #region Métodos Públicos de Instancia

        /// <summary>
        /// Añade un archivo anexo para el envío a FACe.
        /// </summary>
        /// <param name="attachment">Archivo anexo a incluir.</param>
        public void AddAttachment(FaceAttachment attachment)
        {

            _FaceAttachments.Add(attachment);

        }

        #endregion

    }

}
