defmodule FakersApiWeb.GraphQL.Schema do
  use Absinthe.Schema

  alias FakersApiWeb.GraphQL.{Resolvers, Schema}
  alias FakersApi.People

  import_types(Schema.Types)

  query do
    @desc "Get a list of people that match the filter."
    field :people, list_of(:person) do
      arg(:filter, :person_filter)

      resolve(&Resolvers.get_people/2)
    end

    @desc "Get a list of deceased people that match the filter."
    field :deceased_people, list_of(:deceased_person) do
      arg(:filter, :deceased_person_filter)

      resolve(&Resolvers.get_deceased_people/2)
    end

    @desc "Get an address with given id."
    field :address, :address do
      arg(:id, non_null(:id))

      resolve(&Resolvers.get_address/2)
    end

    @desc "Get a contact with given id."
    field :contact, :contact do
      arg(:id, non_null(:id))

      resolve(&Resolvers.get_contact/2)
    end
  end

  @doc """
  Create the dataloader context.

  """
  def context(context) do
    loader =
      Dataloader.new()
      |> Dataloader.add_source(People, People.data())

    Map.put(context, :loader, loader)
  end

  @doc """
  Add dataloader do Absinthe plugins.

  """
  def plugins, do: [Absinthe.Middleware.Dataloader | Absinthe.Plugin.defaults()]
end
