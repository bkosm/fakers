defmodule FakersApiWeb.GraphQL.Schema do
  use Absinthe.Schema

  alias FakersApiWeb.GraphQL.{Resolvers, Schema}
  alias FakersApi.People

  import_types Schema.Types

  query do
    @desc "Get a list of all people."
    field :people, list_of(:person), resolve: &Resolvers.get_people/2

    @desc "Get a list of people with given last name."
    field :people_with_last_name, list_of(:person) do
      arg(:last_name, non_null(:string))

      resolve(&Resolvers.get_people_by_last_name/2)
    end

    @desc "Get a person with given id."
    field :person, :person do
      arg(:id, non_null(:id))

      resolve(&Resolvers.get_person_by_id/2)
    end

    @desc "Get a person with given PESEL."
    field :person_with_pesel, :person do
      arg(:pesel, non_null(:string))

      resolve(&Resolvers.get_person_by_pesel/2)
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
  def plugins, do: [Absinthe.Middleware.Dataloader] ++ Absinthe.Plugin.defaults()
end
