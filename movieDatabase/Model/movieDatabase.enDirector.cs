﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Entity Developer tool using EF Core template.
// Code is generated on: 2023. 04. 26. 2:07:46
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;

namespace Filmadatbazis
{
    public partial class enDirector {

        public enDirector()
        {
            this.enMovie_Directions = new List<enMovie_Direction>();
            OnCreated();
        }

        public int dir_id { get; set; }

        public string dir_fname { get; set; }

        public string dir_lname { get; set; }

        public virtual IList<enMovie_Direction> enMovie_Directions { get; set; }

        #region Extensibility Method Definitions

        partial void OnCreated();

        #endregion
    }

}
