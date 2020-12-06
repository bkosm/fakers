defmodule FakersApi.People.DeceasedPerson do
  use Ecto.Schema
  import Ecto.Changeset
  alias FakersApi.People.Person

  @primary_key false
  schema "deceased_person" do
    field :date_of_death, :date

    belongs_to :person, Person, primary_key: true
  end

  @doc false
  def changeset(deceased_person, attrs) do
    deceased_person
    |> cast(attrs, [:date_of_death, :person_id])
    |> unique_constraint(:primary_key, name: :deceased_person_pkey)
  end
end
