using System;
using System.Collections.Generic;

namespace DBEntity
{
    public class EntityService : EntityBase
    {
        public string Co_Servicio { get; set; }
        public string No_Servicio { get; set; }
        public decimal Mo_Precio { get; set; }
        public string Tx_Descripcion { get; set; }
    }
}
/*
create table TB_Servicio (
    Co_Servicio int PRIMARY KEY not null,
    No_Servicio varchar (50),
    Mo_Precio smallmoney,
    Tx_Descripcion varchar (300)
);
*/