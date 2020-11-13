defmodule FakersApiWeb.Schema.Types do
  use Absinthe.Schema.Notation

  import Absinthe.Resolution.Helpers, only: [dataloader: 1]

  alias FakersApi.People

  @desc "An object that defines an address."
  object :address do
    field :id, :id
    field :city, :string
    field :location, :string
    field :street, :string
    field :voivodeship, :string

    field :people, list_of(:person), description: "List of people assigned to this address."
  end

  @desc "An object that defines a contact."
  object :contact do
    field :id, :id
    field :email, :string
    field :phone_number, :string

    field :people, list_of(:person),
      resolve: dataloader(People.Person),
      description: "List of people reachable with this contact."
  end

  @desc "An object that defines a person."
  object :person do
    field :id, :id
    # field :birth_date, :date
    field :first_name, :string
    field :last_name, :string
    field :pesel, :string
    field :second_name, :string
    field :sex, :string

    field :addresses, list_of(:address),
      resolve: dataloader(People.Address),
      description: "List of addresses that are assigned to this person."

    field :contacts, list_of(:contact),
      resolve: dataloader(People.Contact),
      description: "List of contacts that are assigned to this person."
  end
end
