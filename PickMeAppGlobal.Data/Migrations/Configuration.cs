namespace PickMeAppGlobal.Data.Migrations
{
  using System.Data.Entity.Migrations;

  internal sealed class PickUpConfiguration : DbMigrationsConfiguration<PickMeAppContext>
  {
    public PickMeAppDbInitializer DbInitializer { get; set; }

    public PickUpConfiguration()
    {
      AutomaticMigrationsEnabled = true;
      ContextKey = "PickMeAppGlobal.Data.PickMeAppContext";
      this.DbInitializer = new PickMeAppDbInitializer();
    }

    protected override void Seed(PickMeAppContext context)
    {
      base.Seed(context);
      this.DbInitializer.Seed(context);
    }
  }
}