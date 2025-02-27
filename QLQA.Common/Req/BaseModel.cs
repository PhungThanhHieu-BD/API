﻿using System;
using System.Collections.Generic;
using System.Text;

namespace QLQA.Common.Req
{
    public class BaseModel
    {
        #region -- Methods --

        /// <summary>
        /// Initialize
        /// </summary>
        /// <param name="id">ID</param>
        public BaseModel(int id)
        {
            Id = id;
        }

        #endregion

        #region -- Properties --

        /// <summary>
        /// ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Status
        /// </summary>
        public Enum Status { get; set; }

        /// <summary>
        /// Created by
        /// </summary>
        public int? CreatedBy { get; set; }

        /// <summary>
        /// Created on
        /// </summary>
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Modified by
        /// </summary>
        public int? ModifiedBy { get; set; }

        /// <summary>
        /// Modified on
        /// </summary>
        public DateTime? ModifiedOn { get; set; }

        #endregion
    }
}
