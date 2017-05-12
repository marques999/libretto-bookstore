using System;
using System.Collections.Generic;
using System.IdentityModel.Claims;
using System.IdentityModel.Policy;
using System.Security.Principal;

namespace LibrettoWCF.Authentication
{
    /// <summary>
    /// 
    /// </summary>
    public class AuthorizationPolicy : IAuthorizationPolicy
    {
        /// <summary>
        /// 
        /// </summary>
        private Guid _guid = Guid.NewGuid();

        /// <summary>
        /// 
        /// </summary>
        public string Id => _guid.ToString();

        /// <summary>
        /// 
        /// </summary>
        public ClaimSet Issuer => ClaimSet.System;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="evaluationContext"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public bool Evaluate(EvaluationContext evaluationContext, ref object state)
        {
            evaluationContext.Properties["Principal"] = new CustomPrincipal(GetClientIdentity(evaluationContext));
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="evaluationContext"></param>
        /// <returns></returns>
        private static IIdentity GetClientIdentity(EvaluationContext evaluationContext)
        {
            if (evaluationContext.Properties.TryGetValue("Identities", out object obj) == false)
            {
                throw new Exception("No Identity found");
            }

            var identities = obj as IList<IIdentity>;

            if (identities == null || identities.Count < 1)
            {
                throw new Exception("No Identity found");
            }

            return identities[0];
        }

    }
}