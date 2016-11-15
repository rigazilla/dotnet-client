package org.infinispan.client.hotrod.configuration;

public class ClusterConfigurationBuilder extends AbstractConfigurationChildBuilder {

    private cli.Infinispan.HotRod.Config.ClusterConfigurationBuilder ccb;

	public ClusterConfigurationBuilder(ConfigurationBuilder builder, cli.Infinispan.HotRod.Config.ClusterConfigurationBuilder ccb) {
        super(builder);
        this.ccb=ccb;
	}
	public ClusterConfigurationBuilder addClusterNode(String host, int port)
	{
		ccb.AddClusterNode(host, port);
		return this;
    }
}
