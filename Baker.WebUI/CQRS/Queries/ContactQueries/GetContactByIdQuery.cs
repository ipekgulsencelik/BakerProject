namespace Baker.WebUI.CQRS.Queries.ContactQueries
{
	public class GetContactByIdQuery
	{
		public string Id { get; set; }

		public GetContactByIdQuery(string id)
		{
			Id = id;
		}
	}
}