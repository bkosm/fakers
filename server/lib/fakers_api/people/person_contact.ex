defmodule FakersApi.People.PersonContact do
  use Ecto.Schema
  import Ecto.Changeset
  alias FakersApi.People.{Person, Contact}

  @primary_key false
  schema "person_contact" do
    field :assigned, :date

    belongs_to :person, Person
    belongs_to :contact, Contact
  end

  @doc false
  def changeset(person_contact, attrs) do
    person_contact
    |> cast(attrs, [:assigned, :person_id, :contact_id])
    |> unique_constraint(:composite_key, name: :person_contact_pkey)
  end
end
