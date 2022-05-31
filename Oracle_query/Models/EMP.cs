using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Oracle_query.Models
{
    public class EMP
    {
        public int EMPNO { get; set; }

        [Required(ErrorMessage ="*Name is Required")]
        public string ENAME { get; set; }

        [Required(ErrorMessage = "*Job is Required")]
        public string JOB { get; set; }
        public Nullable<int> MGR { get; set; }

        [Required(ErrorMessage = "*HireDate is Required")]
        public Nullable<DateTime> HIREDATE { get; set; }
        public Nullable<int> SAL { get; set; }
        public Nullable<int> COMM { get; set; }

        
        public Nullable<int> DEPTNO { get; set; }

    }
}