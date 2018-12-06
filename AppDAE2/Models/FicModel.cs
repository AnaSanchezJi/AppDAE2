using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AppDAE2.Models
{
    public class FicModel
    { }
    [Table("eva_cat_edificios")]
    public class eva_cat_edificios
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int16 IdEdificio { get; set; }
        [MaxLength(10)]
        public string Alias { get; set; }
        [MaxLength(50)]
        public string DesEdificio { get; set; }
        public Int16 Prioridad { get; set; }
        [MaxLength(20)]
        public string Clave { get; set; }
        public DateTime FechaReg { get; set; }
        public DateTime FechaUltMod { get; set; }
        [MaxLength(20)]
        public string UsuarioReg { get; set; }
        [MaxLength(20)]
        public string UsuarioMod { get; set; }
        [MaxLength(1)]
        public string Activo { get; set; }
        [MaxLength(1)]
        public string Borrado { get; set; }

    }

    [Table("eva_cat_espacios")]
    public class eva_cat_espacios
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Int16 IdEdificio { get; set; }
        public Int16 IdEspacio { get; set; }
        [MaxLength(20)]
        public string Clave { get; set; }
        [MaxLength(50)]
        public string DesEspacio { get; set; }
        public Int16 Prioridad { get; set; }
        [MaxLength(10)]
        public string Alias { get; set; }
        public Int16 RangoTiempoReserva { get; set; }
        public Int16 Capacidad { get; set; }
        public Int16 IdTipoEstatus { get; set; }
        public Int16 IdEstatus { get; set; }
        [MaxLength(255)]
        public string RefUbicacion { get; set; }
        [MaxLength(1)]
        public string PermiteCruce { get; set; }
        [MaxLength(20)]
        public string Observacion { get; set; }
        [MaxLength(20)]
        public DateTime FechaReg { get; set; }
        [MaxLength(20)]
        public DateTime FechaUltMod { get; set; }
        public string UsuarioReg { get; set; }
        public string UsuarioMod { get; set; }
        [MaxLength(1)]
        public string Activo { get; set; }
        [MaxLength(1)]
        public string Borrado { get; set; }

        //Foreign keys
        public eva_cat_edificios Eva_Cat_Edificios { get; set; }
        public eva_cat_tipos_estatus Eva_Cat_Tipos_Estatus { get; set; }
        public eva_cat_estatus Eva_Cat_Estatus { get; set; }
    }

    [Table("eva_cat_tipos_estatus")]
    public class eva_cat_tipos_estatus
    {
        public Int16 IdTipoEstatus { get; set; }
        public string DesTipoEstatus { get; set; }
        public DateTime FechaReg { get; set; }
        public string UsuarioReg { get; set; }
        public DateTime FechaUltMod { get; set; }
        public string UsuarioMod { get; set; }
        public string Activo { get; set; }
        public string Borrado { get; set; }

    }

    [Table("eva_cat_estatus")]
    public class eva_cat_estatus
    {
        public Int16 IdEstatus { get; set; }
        public Int16 IdTipoEstatus { get; set; }
        public string clave { get; set; }
        public string DesEstatus { get; set; }
        public DateTime FechaReg { get; set; }
        public string UsuarioReg { get; set; }
        public DateTime FechaUltMod { get; set; }
        public string UsuarioMod { get; set; }
        public string Activo { get; set; }
        public string Borrado { get; set; }

        //Foreign Keys
        public eva_cat_tipos_estatus Eva_Cat_Tipos_Estatus { get; set; }
    }

    [Table("eva_cat_tipo_competencias")]
    public class eva_cat_tipo_competencias
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public Int16 IdTipoCompetencia { get; set; }
        public string DesTipoCompetencia { get; set; }
        public string Detalle { get; set; }
        public DateTime FechaReg { get; set; }
        public string UsuarioReg { get; set; }
        public DateTime FechaUltMod { get; set; }
        public string UsuarioMod { get; set; }
        public string Activo { get; set; }
        public string Borrado { get; set; }

        //public List<eva_cat_competencias> competencias { get; set; }

    }

    [Table("eva_cat_competencias")]
    public class eva_cat_competencias
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdCompetencia { get; set; }
        public Int16 IdTipoCompetencia { get; set; }
        public string DesCompetencia { get; set; }
        public string Detalle { get; set; }
        public DateTime FechaReg { get; set; }
        public string UsuarioReg { get; set; }
        public DateTime FechaUltMod { get; set; }
        public string UsuarioMod { get; set; }
        public string Activo { get; set; }
        public string Borrado { get; set; }

        //public List<eva_cat_conocimientos> conocimientos { get; set; }

        //Foreign keys
        public eva_cat_tipo_competencias Eva_Cat_Tipo_Competencias { get; set; }

    }

    [Table("eva_cat_conocimientos")]
    public class eva_cat_conocimientos
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdConocimiento { get; set; }
        public int IdCompetencia { get; set; }
        public string DesConocimiento { get; set; }
        public string Detalle { get; set; }
        public DateTime FechaReg { get; set; }
        public string UsuarioReg { get; set; }
        public DateTime FechaUltMod { get; set; }
        public string UsuarioMod { get; set; }
        public string Activo { get; set; }
        public string Borrado { get; set; }

        //Foreign keys
        public eva_cat_competencias Eva_Cat_Competencias { get; set; }
    }


}
