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

using System;
using System.Collections.Generic;

namespace Irene.Solutions.Facturae.Business.Invoices
{
    /// <summary>
    /// Reprenta una factura.
    /// </summary>
    public class Invoice : Base
    {

        #region Public Properties

        /// <summary>
        /// ServiceKey del API.
        /// </summary>        
        public string ServiceKey { get; internal set; }

        /// <summary>
        /// Identificador del tipo de documento.
        /// </summary>        
        public string DocTypeID { get; set; }

        /// <summary>
        /// Identificador del estado del documento.
        /// </summary>        
        public string Status { get; set; }

        /// <summary>
        /// Fecha emisión de documento.
        /// </summary>        
        public DateTime? DocumentDate { get; set; }

        /// <summary>
        /// Serie de documento.
        /// </summary>
        public string SerieID { get; set; }

        /// <summary>
        /// Incoterm.
        /// </summary>
        public string Incoterm { get; set; }

        /// <summary>
        /// Tipo de factura.
        /// </summary>
        public string InvoiceType { get; set; }

        /// <summary>
        /// Nombre del vendedor.
        /// </summary>        
        public string SellerName { get; set; }

        /// <summary>
        /// Teléfono del vendedor.
        /// </summary>        
        public string SellerAddress { get; set; }

        /// <summary>
        /// Teléfono del vendedor.
        /// </summary>        
        public string SellerPostCode { get; set; }

        /// <summary>
        /// Teléfono del vendedor.
        /// </summary>        
        public string SellerTown { get; set; }

        /// <summary>
        /// Teléfono del vendedor.
        /// </summary>        
        public string SellerProvince { get; set; }

        /// <summary>
        /// Código del país del vendedor.
        /// </summary>
        public string SellerCountryID { get; set; }

        /// <summary>
        /// Teléfono del vendedor.
        /// </summary>        
        public string SellerTelephone { get; set; }

        /// <summary>
        /// Web sel vendedor.
        /// </summary>        
        public string SellerWebAddress { get; set; }

        /// <summary>
        /// Mail del vendedor.
        /// </summary>        
        public string SellerElectronicMail { get; set; }

        /// <summary>
        /// IBAN cuenta cobro vendedor.
        /// </summary>        
        public string SellerIBAN { get; set; }

        /// <summary>
        /// Identidicador del comprador.
        /// Debe utilizarse el identificador fiscal si existe (NIF, VAT Number...).
        /// En caso de no existir, se puede utilizar el número DUNS 
        /// o cualquier otro identificador acordado.
        /// </summary>        
        public string BuyerID { get; set; }

        /// <summary>
        /// Nombre del comprador.
        /// </summary>        
        public string BuyerName { get; set; }

        /// <summary>
        /// Teléfono del vendedor.
        /// </summary>        
        public string BuyerAddress { get; set; }

        /// <summary>
        /// Teléfono del vendedor.
        /// </summary>        
        public string BuyerPostCode { get; set; }

        /// <summary>
        /// Teléfono del vendedor.
        /// </summary>        
        public string BuyerTown { get; set; }

        /// <summary>
        /// Teléfono del vendedor.
        /// </summary>        
        public string BuyerProvince { get; set; }

        /// <summary>
        /// Código del país del comprador.
        /// </summary>
        public string BuyerCountryID { get; set; }

        /// <summary>
        /// Mail del comprador.
        /// </summary>        
        public string BuyerElectronicMail { get; set; }

        /// <summary>
        /// IBAN cuenta pago comprador.
        /// </summary>        
        public string BuyerIBAN { get; set; }

        /// <summary>
        /// Fecha pago.
        /// </summary>        
        public DateTime? PaymentDate { get; set; }

        /// <summary>
        /// Código de tres letras de la moneda.
        /// </summary>
        public string CurrencyID { get; set; }

        /// <summary>
        /// Importe total: Total neto + impuestos soportado
        /// - impuestos repercutidos.
        /// </summary>        
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// Observaciones acerca del documento.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Líneas de factura.
        /// </summary>
        public List<InvoiceItem> Items { get; set; }

        /// <summary>
        /// Líneas de impuestos soportados.
        /// </summary>
        public List<InvoiceTaxesOutput> TaxesOutputs { get; set; }

        /// <summary>
        /// Líneas de impuestos repercutidos.
        /// </summary>
        public List<InvoiceTaxesWithholding> TaxesWithholding { get; set; }

        /// <summary>
        /// Vencimientos.
        /// </summary>
        public List<InvoicePayment> Payments { get; set; }

        /// <summary>
        /// Centros administrativos.
        /// </summary>
        public List<InvoiceAdministrativeCentre> AdministrativeCentres { get; set; }

        #endregion

    }

}
