defmodule FakersApi.PeopleTest do
  use FakersApi.DataCase

  alias FakersApi.People

  describe "people" do
    alias FakersApi.People.Person

    @valid_attrs %{birth_date: ~D[2010-04-17], first_name: "some first_name", last_name: "some last_name", pesel: "11111111111", second_name: "some second_name", sex: "f"}
    @update_attrs %{birth_date: ~D[2011-05-18], first_name: "some updated first_name", last_name: "some updated last_name", pesel: "11111111112", second_name: "some updated second_name", sex: "m"}
    @invalid_attrs %{birth_date: nil, first_name: nil, last_name: nil, pesel: nil, second_name: nil, sex: nil}

    def person_fixture(attrs \\ %{}) do
      {:ok, person} =
        attrs
        |> Enum.into(@valid_attrs)
        |> People.create_person()

      person
    end

    test "list_people/0 returns all people" do
      person = person_fixture()
      assert People.list_people() == [person]
    end

    test "get_person!/1 returns the person with given id" do
      person = person_fixture()
      assert People.get_person!(person.id) == person
    end

    test "create_person/1 with valid data creates a person" do
      assert {:ok, %Person{} = person} = People.create_person(@valid_attrs)
      assert person.birth_date == ~D[2010-04-17]
      assert person.first_name == "some first_name"
      assert person.last_name == "some last_name"
      assert person.pesel == "11111111111"
      assert person.second_name == "some second_name"
      assert person.sex == "f"
    end

    test "create_person/1 with invalid data returns error changeset" do
      assert {:error, %Ecto.Changeset{}} = People.create_person(@invalid_attrs)
    end

    test "update_person/2 with valid data updates the person" do
      person = person_fixture()
      assert {:ok, %Person{} = person} = People.update_person(person, @update_attrs)
      assert person.birth_date == ~D[2011-05-18]
      assert person.first_name == "some updated first_name"
      assert person.last_name == "some updated last_name"
      assert person.pesel == "11111111112"
      assert person.second_name == "some updated second_name"
      assert person.sex == "m"
    end

    test "update_person/2 with invalid data returns error changeset" do
      person = person_fixture()
      assert {:error, %Ecto.Changeset{}} = People.update_person(person, @invalid_attrs)
      assert person == People.get_person!(person.id)
    end

    test "delete_person/1 deletes the person" do
      person = person_fixture()
      assert {:ok, %Person{}} = People.delete_person(person)
      assert_raise Ecto.NoResultsError, fn -> People.get_person!(person.id) end
    end

    test "change_person/1 returns a person changeset" do
      person = person_fixture()
      assert %Ecto.Changeset{} = People.change_person(person)
    end
  end
end
