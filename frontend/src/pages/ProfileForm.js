/* global google */
import { useState } from "react";
import { IMaskInput } from "react-imask";
import Script from "react-load-script";

import { Salutation } from "../enums/Salutation";
import { WorkStatus } from "../enums/WorkStatus";

import { getCountryCallingCode } from 'libphonenumber-js';
import countryList from "react-select-country-list";

const initialProfile = {
  userId: "",
  name: {
    salutation: "",
    firstName: "",
    middleName: "",
    lastName: "",
    preferredFirstName: "",
    pronouns: "",
  },
  phone: "",
  phoneExtension: "",
  profileImageUrl: "",
  workStatus: "",
  address: {
    unit: "",
    streetAddress: "",
    city: "",
    province: "",
    postalCode: "",
    country: "",
  },
  experiences: [],
  skills: [],
  educations: [],
  links: [],
};

const addressFieldLabels = {
  US: { region: "State", postal: "ZIP Code" },
  CA: { region: "Province", postal: "Postal Code" },
  GB: { region: "County", postal: "Postcode" },
  AU: { region: "State", postal: "Postcode" },
  DEFAULT: { region: "Province", postal: "Postal Code" },
};

const countryOptions = countryList().getData();

const priorityCountryCodes = ["CA", "US"];

const priorityCountries = countryOptions.filter((opt) =>
  priorityCountryCodes.includes(opt.value.toUpperCase())
);
const otherCountries = countryOptions.filter(
  (opt) => !priorityCountryCodes.includes(opt.value.toUpperCase())
);

function ProfileForm() {
  const [profile, setProfile] = useState(initialProfile);
  const [googleLoaded, setGoogleLoaded] = useState(false);
  const [suggestions, setSuggestions] = useState([]);
  const [inputValue, setInputValue] = useState("");

  const handleScriptLoad = () => {
    setGoogleLoaded(true);
    console.log("Google Maps API loaded successfully.");
  };

    const handleInputChange = (e) => {
    const value = e.target.value;
    setInputValue(value);

    if (googleLoaded && value) {
      const autocomplete = new google.maps.places.AutocompleteSuggestion();
      autocomplete.getSuggestions({ input: value }, (results, status) => {
        if (status === google.maps.places.PlacesServiceStatus.OK) {
          setSuggestions(results);
        } else {
          console.error("Autocomplete error:", status);
        }
      });
    }
  };

  const handleSuggestionSelect = (suggestion) => {
    setInputValue(suggestion.description);
    setSuggestions([]);
    setProfile((prev) => ({
      ...prev,
      address: { ...prev.address, streetAddress: suggestion.description },
    }));
  };

  const handleChange = (e) => {
    const { name, value } = e.target;
    setProfile((prev) => ({
      ...prev,
      [name]: value,
    }));
  };

  const handleAddressChange = (e) => {
    const { name, value } = e.target;
    setProfile((prev) => ({
      ...prev,
      address: {
        ...prev.address,
        [name]: value,
      },
    }));
  };

  const handleNameChange = (e) => {
    const { name, value } = e.target;
    setProfile((prev) => ({
      ...prev,
      name: {
        ...prev.name,
        [name]: value,
      },
    }));
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    console.log(profile);
  };

  console.log("Country code for prefix:", profile.address.country);
  console.log("Country calling code:", getCountryCallingCode(profile.address.country));
  const countryPrefix = profile.address.country
    ? `+${getCountryCallingCode(profile.address.country.toUpperCase())}`
    : "";

  const countryCode = profile.address.country
    ? profile.address.country.toUpperCase()
    : "";
  const labels = addressFieldLabels[countryCode] || addressFieldLabels.DEFAULT;

  return (
    <>
      <Script
        url="https://maps.googleapis.com/maps/api/js?key=AIzaSyC3LcKd3btb6Yf5xjc_NrXwjtnezEbOdLI&libraries=places&v=beta"
        attributes={{ async: true, defer: true }}
        onLoad={handleScriptLoad}
        onError={() => console.error("Failed to load Google Maps API.")}
      />
      {googleLoaded ? (
        <form onSubmit={handleSubmit}>
          <fieldset>
            <legend>Name</legend>
            <label>
              Salutation:
              <select
                name="salutation"
                value={profile.name.salutation}
                onChange={handleNameChange}
              >
                <option value="">Select...</option>
                {Salutation.map((s) => (
                  <option key={s} value={s}>
                    {s}
                  </option>
                ))}
              </select>
            </label>
            <br />
            <label>
              First Name:{" "}
              <input
                name="firstName"
                value={profile.name.firstName}
                onChange={handleNameChange}
              />
            </label>
            <br />
            <label>
              Middle Name:{" "}
              <input
                name="middleName"
                value={profile.name.middleName}
                onChange={handleNameChange}
              />
            </label>
            <br />
            <label>
              Last Name:{" "}
              <input
                name="lastName"
                value={profile.name.lastName}
                onChange={handleNameChange}
              />
            </label>
            <br />
            <label>
              Preferred First Name:{" "}
              <input
                name="preferredFirstName"
                value={profile.name.preferredFirstName}
                onChange={handleNameChange}
              />
            </label>
            <br />
            <label>
              Pronouns:{" "}
              <input
                name="pronouns"
                value={profile.name.pronouns}
                onChange={handleNameChange}
              />
            </label>
            <br />
          </fieldset>

          <label>
            Phone:
            <span style={{ marginRight: "8px" }}>
              <input
                type="text"
                value={countryPrefix}
                readOnly
                style={{
                  width: "50px",
                  background: "#eee",
                  border: "1px solid #ccc",
                  textAlign: "center",
                }}
                tabIndex={-1}
              />
            </span>
            <IMaskInput
              mask="(000) 000-0000"
              name="phone"
              value={profile.phone}
              onAccept={(value) =>
                setProfile((prev) => ({ ...prev, phone: value }))
              }
              placeholder="(604) 867-5309"
              required
            />
          </label>
          <br />
          <br />
          <label>
            Phone Extension:{" "}
            <input
              name="phoneExtension"
              value={profile.phoneExtension}
              onChange={handleChange}
            />
          </label>
          <br />
          <label>
            Profile Image URL:{" "}
            <input
              name="profileImageUrl"
              value={profile.profileImageUrl}
              onChange={handleChange}
            />
          </label>
          <br />
          <label>
            Work Status:
            <select
              name="workStatus"
              value={profile.workStatus}
              onChange={handleChange}
              required
            >
              {!profile.workStatus && <option value="">Select...</option>}
              {WorkStatus.map((s) => (
                <option key={s} value={s}>
                  {s}
                </option>
              ))}
            </select>
          </label>
          <br />

          <fieldset>
            <legend>Address</legend>
            <div style={{ display: "flex", gap: "12px", alignItems: "flex-end" }}>
              <label style={{ marginBottom: 0, display: "flex", alignItems: "center" }}>
                Unit:
                <input
                  name="unit"
                  value={profile.address.unit}
                  onChange={handleAddressChange}
                  style={{ marginLeft: 4 }}
                />
              </label>
              <label style={{ marginBottom: 0, display: "flex", alignItems: "center" }}>
                Street Address:
                <div style={{ flex: 1 }}>
                  <input
                    type="text"
                    value={inputValue}
                    onChange={handleInputChange}
                    placeholder="Search Address..."
                    style={{ marginLeft: 4 }}
                  />
                  <div className="autocomplete-dropdown-container">
                    {suggestions.map((suggestion) => (
                      <div
                        key={suggestion.place_id}
                        onClick={() => handleSuggestionSelect(suggestion)}
                        style={{
                          cursor: "pointer",
                          padding: "8px",
                          borderBottom: "1px solid #ccc",
                        }}
                      >
                        {suggestion.description}
                      </div>
                    ))}
                  </div>
                </div>
              </label>
            </div>
            <label>
              City:{" "}
              <input
                name="city"
                value={profile.address.city}
                onChange={handleAddressChange}
              />
            </label>
            <label>
              {labels.region}:
              <input
                name="province"
                value={profile.address.province}
                onChange={handleAddressChange}
              />
            </label>
            <br />
            <label>
              {labels.postal}:
              <input
                name="postalCode"
                value={profile.address.postalCode}
                onChange={handleAddressChange}
              />
            </label>
            <br />
            <label>
              Country:
              <select
                name="country"
                value={profile.address.country}
                onChange={handleAddressChange}
                required
              >
                {!profile.address.country && <option value="">Select...</option>}
                {priorityCountries.map((option) => (
                  <option key={option.value} value={option.value}>
                    {option.label}
                  </option>
                ))}
                <option disabled>──────────</option>
                {otherCountries.map((option) => (
                  <option key={option.value} value={option.value}>
                    {option.label}
                  </option>
                ))}
              </select>
            </label>
            <br />
          </fieldset>

          <button type="submit">Save Profile</button>
        </form>
      ) : (
        <div>Loading Google Maps...</div>
      )}
    </>
  );
}

export default ProfileForm;