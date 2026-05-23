using EZtock.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace EZtock.Domain.Entities
{
    public class SubscriptionFeature : AuditableEntity
    {
        public Guid Id { get; set; }
        public Guid TenantId { get; set; }
        public Tenant Tenant { get; set; }
        public Guid FeatureId { get; set; }
        public Feature Feature { get; set; }

    }
}
