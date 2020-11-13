defmodule FakersApiWeb.GraphQL.Schema.Types do
  use Absinthe.Schema.Notation
  import Absinthe.Resolution.Helpers, only: [dataloader: 1]
  alias FakersApi.People

  import_types(Absinthe.Type.Custom)

  @desc "An object that defines an address."
  object :address do
    field :id, non_null(:id)
    field :city, non_null(:string)
    field :location, non_null(:string)
    field :street, non_null(:string)
    field :voivodeship, non_null(:string)

    @desc "List of people assigned to this address."
    field :people, list_of(:person), resolve: dataloader(People)
  end

  @desc "An object that defines a contact."
  object :contact do
    field :id, non_null(:id)
    field :email, non_null(:string)
    field :phone_number, :string

    @desc "List of people reachable with this contact info."
    field :people, list_of(:person), resolve: dataloader(People)
  end

  @desc "An object that defines a person."
  object :person do
    field :id, non_null(:id)
    field :birth_date, non_null(:date)
    field :first_name, non_null(:string)
    field :last_name, non_null(:string)
    field :pesel, non_null(:string)
    field :second_name, :string
    field :sex, non_null(:string)

    @desc "List of addresses that are assigned to this person."
    field :addresses, list_of(:address), resolve: dataloader(People)

    @desc "List of contacts that are assigned to this person."
    field :contacts, list_of(:contact), resolve: dataloader(People)
  end

  @desc "Person filter type."
  input_object :person_filter do
    field :id, :integer
    field :birth_date, :date
    field :first_name, :string
    field :second_name, :string
    field :last_name, :string
    field :pesel, :string
    field :sex, :string
  end

  @desc "An object that represents an association between a person and an address."
  object :person_address do
    field :person_id, non_null(:id)
    field :address_id, non_null(:id)
    field :assigned, non_null(:date)

    @desc "The associated person."
    field :person, list_of(:person), resolve: dataloader(People)

    @desc "The associated address."
    field :address, list_of(:address), resolve: dataloader(People)
  end

  @desc "An object that represents an association between a person and a contact."
  object :person_contact do
    field :person_id, non_null(:id)
    field :contact_id, non_null(:id)
    field :assigned, non_null(:date)

    @desc "The associated person."
    field :person, list_of(:person), resolve: dataloader(People)

    @desc "The associated address."
    field :contact, list_of(:contact), resolve: dataloader(People)
  end

  @desc "An object that represents a deceased person."
  object :deceased_person do
    field :person_id, non_null(:id)
    field :date_of_death, non_null(:date)

    @desc "The person's profile."
    field :person, list_of(:person), resolve: dataloader(People)
  end
end
