using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetteRFlow.Shared.Models
{
    public class BrfAvvikelse
    {
        public int Id { get; set; }

        public int BrfId { get; set; }
        public Brf? Brf { get; set; }

        public string Faltnamn { get; set; } = string.Empty;
        public string VardeGrunddata { get; set; } = string.Empty;
        public string VardeFormular { get; set; } = string.Empty;

        public bool Granskad { get; set; } = false;
        public DateTime SkapadDatum { get; set; } = DateTime.UtcNow;

        public int? FormSubmissionId { get; set; }
        public FormSubmission? FormSubmission { get; set; }
    }
}