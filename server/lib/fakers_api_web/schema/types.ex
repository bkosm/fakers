defmodule FakersApiWeb.Schema.Types do
    use Absinthe.Schema.Notation
    alias FakersApiWeb.Resolvers

    @desc "An object that defines a person."
    object :person do
        #field :birth_date, :date
        field :first_name, :string
        field :last_name, :string
        field :pesel, :string
        field :second_name, :string
        field :sex, :string
    end

    object :get_people do
        @desc """
        Get a list of all people.
        """

        field :people, list_of(:person) do
            resolve(&Resolvers.People.list_people/2)
        end
    end
end