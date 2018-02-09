using Newtonsoft.Json;

namespace Domain.UIDomain
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
        /// </summary
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// 菜单父Id
        /// </summary>
        [JsonProperty(PropertyName = "pId")]
        public string Pid { get; set; }

        /// <summary>
        /// 是否打开
        /// </summary>
        [JsonProperty(PropertyName = "open")]
        public bool Open { get; set; } = true;
    }
}