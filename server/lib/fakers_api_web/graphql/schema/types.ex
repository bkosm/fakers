defmodule FakersApiWeb.GraphQL.Schema.Types do
  use Absinthe.Schema.Notation

  import_types(Absinthe.Type.Custom)

  @desc "An object that defines an address."
  object :address do
    field :id, :id
    field :city, :string
    field :location, :string
    field :street, :string
    field :voivodeship, :string

    field :people, list_of(:person) do
      #TODO resolve
      description("List of people assigned to this address.")
    end
  end

  @desc "An object that defines a contact."
  object :contact do
    field :id, :id
    field :email, :string
    field :phone_number, :string

    field :people, list_of(:person) do
      #TODO resolve
      description("List of people reachable with this contact.")
    end
  end

  @desc "An object that defines a person."
  object :person do
    field :id, :id
    field :birth_date, :date
    field :first_name, :string
    field :last_name, :string
    field :pesel, :string
    field :second_name, :string
    field :sex, :string

    field :addresses, list_of(:address) do
      resolve(fn parent, _, _ ->
        addresses = FakersApi.Repo.all(Ecto.assoc(parent, :addresses))

        {:ok, addresses}
      end)
      description("List of addresses that are assigned to this person.")
    end

    field :contacts, list_of(:contact) do
      resolve(fn parent, _, _ ->
        contacts = FakersApi.Repo.all(Ecto.assoc(parent, :contacts))

        {:ok, contacts}
      end)
      description("List of contacts that are assigned to this person.")
    end
  end
end
