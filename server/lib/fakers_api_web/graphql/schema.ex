defmodule FakersApiWeb.GraphQL.Schema do
  use Absinthe.Schema

  alias FakersApiWeb.GraphQL.Schema.Types.{Objects, Inputs, Filters}
  alias FakersApiWeb.GraphQL.Resolvers.{Query}
  alias FakersApi.People

  import_types(Absinthe.Type.Custom)
  import_types(Objects)
  import_types(Inputs)
  import_types(Filters)

  query do
    @desc "Get a list of people that match the filter."
    field :people, list_of(:person) do
      arg(:filter, :person_filter)

      resolve(&Query.get_people/2)
    end

    @desc "Get a list of deceased people that match the filter."
    field :deceased_people, list_of(:deceased_person) do
      arg(:filter, :deceased_person_filter)

      resolve(&Query.get_deceased_people/2)
    end

    @desc "Get an address with given id."
    field :addresses, list_of(:address) do
      arg(:filter, :address_filter)

      resolve(&Query.get_addresses/2)
    end

    @desc "Get a contact with given id."
    field :contacts, list_of(:contact) do
      arg(:filter, :contact_filter)

      resolve(&Query.get_contacts/2)
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
