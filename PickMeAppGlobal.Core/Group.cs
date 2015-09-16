
using System;
using System.Collections.Generic;

using PickMeAppGlobal.Core.Base;

namespace PickMeAppGlobal.Core
{
  public class Group : BaseEntity
  {
    public string Name { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? LastUpdatedDate { get; set; }

    public virtual List<MetaTag> MetaTags { get; set; }

    public virtual List<UserGroupInfo> UserGroupInfos { get; set; }
  }
}