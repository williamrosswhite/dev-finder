# My .NET and React Application

This is my learning project to learn React better, and to not let my existing skill atrophe.

## Ultimate aim

- I want to make a site where prospective software companies can shop for available devs
- 

## Roadmap

1. I suppose the first step will be to set up the database structure with the tables and columns I'll need
   - I'll need users, complete with columns for all the different resume type data I'll want.
   - I'll need some sort of image bucket locally.
2. Some front end form page to create new profiles.
3. A data seeder to populate the database with a lot of dummy profiles.
4. Then I'll need to start working on the main page.
   - I'll need to design cards for individual profiles with vital stats
   - I'll need search discriminators, so users can populate with desired traits
   - I'll need some sort of idealizing algorithm to compare different elements to generate a ranking based on search parameters.
   - I'll want lazy loading.
   - I'd like to implement like, location finders, school finders like on resumes
   - Should have to put country first, then automatically populate state vs province and phone prefix etc
5. Then I'll need to shift storage and hosting to online, and make it able to easily switch between.
5. Eventually I'll want to develop some sort of API potential employers can plug into.


## Getting Started

### Prerequisites

- .NET SDK
- Node.js and npm

### Backend Setup

1. Navigate to the `backend` directory.
2. Restore the dependencies:
   ```
   dotnet restore
   ```
3. Run the application:
   ```
   dotnet run
   ```

### Frontend Setup

1. Navigate to the `frontend` directory.
2. Install the dependencies:
   ```
   npm install
   ```
3. Start the React application:
   ```
   npm start
   ```

## Contributing

Feel free to submit issues or pull requests for improvements or bug fixes.

## License

This project is licensed under the MIT License.