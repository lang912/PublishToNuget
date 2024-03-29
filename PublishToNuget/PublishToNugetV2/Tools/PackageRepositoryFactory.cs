﻿using NuGet.Configuration;
using NuGet.Protocol.Core.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublishToNugetV2.Tools
{
    public class PackageRepositoryFactory
    {
        public static SourceRepository CreateRepository(PackageSource packageSource, IEnumerable<Lazy<INuGetResourceProvider>> additionalProviders)
        {
            var providers = Repository.Provider.GetCoreV3();

            if (additionalProviders != null)
            {
                providers = providers.Concat(additionalProviders);
            }

            return Repository.CreateSource(providers, packageSource);
        }

        public static SourceRepository CreateRepository(PackageSource packageSource) => CreateRepository(packageSource, null);

        public static SourceRepository CreateRepository(string source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            try
            {
                var uri = new Uri(source);
            }
            catch (UriFormatException)
            {
                return null;
            }

            return CreateRepository(new PackageSource(source));
        }
    }
}
