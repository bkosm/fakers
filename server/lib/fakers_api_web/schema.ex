defmodule FakersApiWeb.Schema do
    use Absinthe.Schema
    alias FakersApiWeb.Schema

    import_types(Schema.Types)

    query do
        import_fields(:get_people)
    end

end