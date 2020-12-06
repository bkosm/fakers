defmodule FakersApi.People.Contact do
  use Ecto.Schema
  import Ecto.Changeset
  alias FakersApi.People.PersonContact

  schema "contact" do
    field :email, :string
    field :phone_number, :string

    has_many :person_contacts, PersonContact
    has_many :people, through: [:person_contacts, :person]
  end

  @doc false
  def changeset(contact, attrs) do
    contact
    |> cast(attrs, [:email, :phone_number])
    |> validate_required([:email])
  end
end
