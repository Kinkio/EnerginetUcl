using System;
using AutoFixture;
using AutoFixture.AutoMoq;

namespace EnerginetDemo.Tests;

public abstract class TestBase<TSut>
    where TSut : class
{
    protected TSut Sut => LazySut.Value;

    protected IFixture Fixture { get; }

    private Lazy<TSut> LazySut { get; }

    private TSut CreateSut() => Fixture.Create<TSut>();

    protected TestBase()
    {
        LazySut = new Lazy<TSut>(CreateSut);

        Fixture = new Fixture();
        Fixture.Customize(new AutoMoqCustomization());
    }
}
