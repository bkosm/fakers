defmodule FakersApiWeb.Schema do
  use Absinthe.Schema
  alias FakersApiWeb.{Schema, Resolvers}

  import_types(Schema.Types)

  query do
    @desc "Get a list of all people."
    field :people, list_of(:person) do
      resolve(&Resolvers.People.get_people/3)
    end

    @desc "Get a person with given id."
    field :person, :person do
      arg(:id, non_null(:id))
      resolve(&Resolvers.People.get_person/3)
    end

    @desc "Get an address with given id."
    field :address, :address do
      arg(:id, non_null(:id))
      resolve(&Resolvers.People.get_address/3)
    end

    @desc "Get a contact with given id."
    field :contact, :contact do
      arg(:id, non_null(:id))
      resolve(&Resolvers.People.get_contact/3)
    end
  end
end
