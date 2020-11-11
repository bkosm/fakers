defmodule FakersApi.People.Person do
  use Ecto.Schema
  import Ecto.Changeset

  schema "person" do
    field :birth_date, :date
    field :first_name, :string
    field :last_name, :string
    field :pesel, :string
    field :second_name, :string
    field :sex, :string

    timestamps()
  end

  @doc false
  def changeset(person, attrs) do
    person
    |> cast(attrs, [:pesel, :first_name, :second_name, :last_name, :sex, :birth_date])
    |> validate_required([:pesel, :first_name, :second_name, :last_name, :sex, :birth_date])
    |> unique_constraint(:pesel)
  end
end
