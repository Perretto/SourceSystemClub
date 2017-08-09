using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SystemClub.Models
{
    [Table("Agregado")]
    public class Agregado
    {
        [Column("idAgregado")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual Guid idAgregado { get; set; }

        [Index("IX_Socio", IsClustered = false)]
        [Column("idSocio")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual Guid SocioID { get; set; }
        public virtual Socio Socio { get; set; }

        [Column("NomeAgregado")]
        [StringLength(200)]
        [Display(Name = "Nome do Agregado")]
        public virtual string NomeAgregado { get; set; }

        [Column("Sexo")]
        [StringLength(50)]
        [Display(Name = "Sexo do Agregado")]
        public virtual string Sexo { get; set; }

        [Column("DtNascimento")]
        [Display(Name = "Data de nascimento do Agregado")]
        public virtual DateTime DtNasc { get; set; }

        [Column("CPF")]
        [StringLength(20)]
        [Display(Name = "CPF do Agregado")]
        public virtual string CPF { get; set; }

        [Column("RG")]
        [StringLength(20)]
        [Display(Name = "RG do Agregado")]
        public virtual string RG { get; set; }

        [Column("CertNascimento")]
        [StringLength(70)]
        [Display(Name = "Certidao de Nascimento do Agregado")]
        public virtual string CertNascimento { get; set; }

        [Column("Parentesco")]
        [Display(Name = "Grau de parentesco do Agregado")]
        public virtual Guid Parentesco { get; set; }

        [Column("Observacoes", TypeName = "varchar(MAX)")]
        [Display(Name = "Observacoes do dependente")]
        public virtual string Observacoes { get; set; }

        [Column("Guarda")]
        [Display(Name = "Guarda do dependente")]
        public virtual bool Guarda { get; set; }

        [Column("NeceEspecial")]
        [Display(Name = "Necessidades especiais do agregado")]
        public virtual bool NeceEspecial { get; set; }

        [Column("LibDiretoria")]
        [Display(Name = "Liberado pela diretoria")]
        public virtual bool LibDiretoria { get; set; }



    }
}