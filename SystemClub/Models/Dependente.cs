using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SystemClub.Models
{
    [Table("Dependente")]
    public class Dependente
    {
        [Column("id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual Guid idDependente { get; set; }

        [Index("IX_Socio", IsClustered = false)]
        [Column("idSocio")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual Guid SocioID { get; set; }
        public virtual Socio Socio { get; set; }


        [Column("NomeDependente")]
        [StringLength(200)]
        [Display(Name = "Nome do Dependente")]
        public virtual string NomeDependente { get; set; }

        [Column("Sexo")]
        [StringLength(50)]
        [Display(Name = "Sexo do Dependente")]
        public virtual string Sexo { get; set; }

        [Column("DtNascimento")]
        [Display(Name = "Data de nascimento do Dependente")]
        public virtual DateTime DtNasc { get; set; }

        [Column("CPF")]
        [StringLength(20)]
        [Display(Name = "CPF do Dependente")]
        public virtual string CPF { get; set; }

        [Column("RG")]
        [StringLength(20)]
        [Display(Name = "RG do Dependente")]
        public virtual string RG { get; set; }

        [Column("CertNascimento")]
        [StringLength(70)]
        [Display(Name = "Certidao de Nascimento do Dependente")]
        public virtual string CertNascimento { get; set; }

        [Column("Parentesco")]
        [Display(Name = "Grau de parentesco do Dependente")]
        public virtual Guid Parentesco { get; set; }

        [Column("Observacoes", TypeName = "varchar(MAX)")]
        [Display(Name = "Observacoes do dependente")]
        public virtual string Observacoes { get; set; }

        [Column("Guarda")]
        [Display(Name = "Guarda do dependente")]
        public virtual bool Guarda { get; set; }

        [Column("NeceEspecial")]
        [Display(Name = "Necessidades especiais")]
        public virtual bool NeceEspecial { get; set; }

        [Column("LibDiretoria")]
        [Display(Name = "Liberado pela diretoria")]
        public virtual bool LibDiretoria { get; set; }


    }
}