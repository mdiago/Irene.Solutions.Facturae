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

namespace Irene.Solutions.Facturae.Business.Invoices
{
    /// <summary>
    /// Representa una línea de factura.
    /// </summary>
    public class InvoiceItem : BaseItem
    {

        #region Public Properties

        /// <summary>
        /// Identificador del item.
        /// </summary>        
        public string ItemID { get; set; }

        /// <summary>
        /// Nombre del item.
        /// </summary>        
        public string ItemName { get; set; }

        /// <summary>
        /// Unidad de medida.
        /// </summary>        
        public string UnitOfMeasure { get; set; }

        /// <summary>
        /// Texto relacionado con el item.
        /// (Campo auxiliar para descripciones más
        /// largas de 70 caracteres).
        /// </summary>        
        public string ItemText { get; set; }

        /// <summary>
        /// Cantidad.
        /// </summary>        
        public decimal Quantity { get; set; }

        /// <summary>
        /// Precio.
        /// </summary>        
        public decimal NetPrice { get; set; }

        /// <summary>
        /// Importe bruto antes de descuentos. Es igual
        /// al producto de GrossPrice por Quantity. 
        /// </summary>        
        public decimal GrossAmount { get; set; }

        /// <summary>
        /// Precio bruto antes de descuentos.
        /// </summary>        
        public decimal GrossPrice { get; set; }

        /// <summary>
        /// Importe neto después de descuentos. Igual a
        /// NetPrice por Quantity.
        /// </summary>        
        public decimal NetAmount { get; set; }

        /// <summary>
        /// Porcentaje de descuento aplicado.
        /// </summary>
        public decimal DiscountRate { get; set; }

        /// <summary>
        /// Total impuestos soportados / repercutidos.
        /// </summary>        
        public decimal TaxesOutput { get; set; }

        /// <summary>
        /// Total impuestos retenidos.
        /// </summary>        
        public decimal TaxesWithHolding { get; set; }

        /// <summary>
        /// Importe neto + impuestos soportados - impuestos retenidos.
        /// </summary>        
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// Identificador del pedido del que deriva.
        /// </summary>        
        public string OrderID { get; set; }

        /// <summary>
        /// Ejercicio al que pertenece el pedido del que deriva.
        /// </summary>
        public string OrderYear { get; set; }

        /// <summary>
        /// Número de línea o posición en el pedido del que deriva.
        /// </summary>        
        public int OrderPosition { get; set; }

        /// <summary>
        /// Identificador del albarán del que deriva.
        /// </summary>        
        public string DeliveryID { get; set; }

        /// <summary>
        /// Ejercicio al que pertenece el albarán del que deriva.
        /// </summary>
        public string DeliveryYear { get; set; }

        /// <summary>
        /// Número de línea o posición en el albarán del que deriva.
        /// </summary>        
        public int DeliveryPosition { get; set; }

        #endregion

    }

}
