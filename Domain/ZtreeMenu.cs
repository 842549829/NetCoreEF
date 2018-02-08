using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Domain
{
    public class ZtreeMenu
    {
        /// <summary>
        /// 菜单Id
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// 菜单名称
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// 菜单父Id
        /// </summary>
        public string pId { get; set; }

        /// <summary>
        /// 是否打开
        /// </summary>
        public bool open { get; set; } = true;
    }
}