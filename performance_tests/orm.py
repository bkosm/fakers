from gql import gql, Client
from gql.transport.aiohttp import AIOHTTPTransport
import time

def current_ms() -> int:
    return round(time.time() * 1000)


def duration_ms(start: int) -> int:
    return current_ms() - start

def execute(query):
    start = current_ms()
    result = client.execute(query)
    duration = duration_ms(start)
    return result, duration


transport = AIOHTTPTransport(url="http://localhost:4000/")

client = Client(transport=transport, fetch_schema_from_transport=True)

query1 = gql(
    """
    {
        people(filter: {id: 4}) {
            id
            firstName
            pesel
        }
    }
    """
)

query2 = gql(
    """
    {
        people(filter: {id: 4}) {
            id
            firstName
            pesel
            contacts {
                email
                phoneNumber
            }
            addresses {
                street 
                location
            }
        }
    }
    """
)

insert = gql(
    """
    mutation {
        createPerson(
            birthDate: "2010-01-01"
            firstName: "New"
            lastName: "Person"
            pesel: "12345678902"
            sex: "f"
        ) {
            id
        }
    }
    """
)

update = gql(
    """
    mutation {
        modifyPerson(
            id: 4
            firstName: "NewName"
        ) {
            id
        }
    }
    """
)


res, dur = execute(query1)
print(f"simple select = {dur} [ms]")

res, dur = execute(query2)
print(f"joining select = {dur} [ms]")

res, dur = execute(insert)
print(f"insert operation = {dur} [ms]")

res, dur = execute(update)
print(f"update operation = {dur} [ms]")
