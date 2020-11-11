defmodule FakersApi.People.PersonAddress do
  use Ecto.Schema
  import Ecto.Changeset
  alias FakersApi.People.{Person, Address}

  @primary_key false
  schema "person_address" do
    field :assigned, :date

    belongs_to :person, Person
    belongs_to :address, Address
  end

  @doc false
  def changeset(person_address, attrs) do
    person_address
    |> cast(attrs, [:assigned, :person_id, :address_id])
    |> unique_constraint(:composite_key, name: :person_address_pkey)
  end
end
