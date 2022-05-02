using System;
using System.Collections.Generic;

namespace DBEntity
{
    public class EntityEmployee : EntityBase
    {
        public string Co_Empleado { get; set; }
        public string Co_Persona { get; set; }
        public decimal Co_Funcion { get; set; }
        //public string Pw_Empleado { get; set; }
        public string Tx_EmailCorporativo { get; set; }
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