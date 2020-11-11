defmodule FakersApi.Repo.Migrations.CreatePerson do
  use Ecto.Migration

  def change do
    create table(:person) do
      add :pesel, :string
      add :first_name, :string
      add :second_name, :string
      add :last_name, :string
      add :sex, :string
      add :birth_date, :date

      timestamps()
    end

    create unique_index(:person, [:pesel])
  end
end
