export const homeStyles = {
  // Layout
  layoutContainer: "max-w-7xl mx-auto px-6 lg:px-8",

  // Hero Section - MODERNIZADO
  hero: "relative h-screen overflow-hidden",
  heroSection: "relative h-screen",
  heroBackground: "fixed z-[-2] inset-0 w-full h-full",
  heroVideo: "w-full h-screen object-cover fixed inset-0 brightness-50", // Escurecido
  heroOverlay: "fixed inset-0 bg-gradient-to-br from-black/90 via-black/70 to-black/90 z-[-1]",
  heroGradient: "absolute inset-0 bg-gradient-to-t from-black/60 via-transparent to-black/40 z-[-1]",
  heroContent: "h-screen flex justify-center flex-col relative z-10 text-center lg:text-left",
  heroTitle: "text-4xl md:text-6xl lg:text-7xl font-black text-white leading-tight mb-8",
  heroHighlight: "bg-gradient-to-r from-[#D9782C] to-[#f59e0b] bg-clip-text text-transparent",
  heroSubtitle: "text-xl md:text-2xl text-gray-200 mb-12 max-w-3xl mx-auto lg:mx-0 leading-relaxed",
  heroButtonWrapper: "flex flex-col sm:flex-row gap-4 justify-center lg:justify-start items-center",
  heroButton: "px-8 py-4 bg-gradient-to-r from-[#D9782C] to-[#f59e0b] text-white font-bold rounded-2xl hover:shadow-2xl hover:shadow-orange-500/30 transition-all duration-500 transform hover:scale-105 flex items-center group",
  heroButtonSecondary: "px-8 py-4 bg-white/10 backdrop-blur-md text-white font-bold rounded-2xl border border-white/20 hover:bg-white/20 transition-all duration-500 transform hover:scale-105",
  
  // Scroll Indicator
  scrollIndicator: "absolute bottom-8 left-1/2 transform -translate-x-1/2",
  scrollArrow: "w-6 h-10 border-2 border-white rounded-full flex justify-center before:content-[''] before:w-1 before:h-3 before:bg-white before:rounded-full before:animate-bounce",

  // Features Section
  featuresSection: "py-20 lg:py-32 bg-gradient-to-b from-white to-gray-50",
  sectionHeader: "text-center max-w-3xl mx-auto mb-16 lg:mb-20",
  sectionTitle: "text-3xl md:text-5xl font-black text-gray-900 mb-6",
  sectionSubtitle: "text-xl text-gray-600 leading-relaxed",
  featuresGrid: "grid grid-cols-1 md:grid-cols-3 gap-8 lg:gap-12",
  featureCard: "bg-white rounded-3xl p-8 shadow-2xl shadow-gray-200/50 border border-gray-100 hover:shadow-2xl hover:shadow-[#D9782C]/20 transition-all duration-500 cursor-pointer group",
  featureIcon: "w-20 h-20 bg-gradient-to-br from-[#D9782C] to-[#f59e0b] rounded-2xl flex items-center justify-center text-white mb-6 group-hover:scale-110 transition-transform duration-500",
  featureTitle: "text-2xl font-bold text-gray-900 mb-4",
  featureDescription: "text-gray-600 leading-relaxed",

  // CTA Section
  ctaSection: "relative py-20 lg:py-32 overflow-hidden",
  ctaBackground: "absolute inset-0 bg-gradient-to-br from-[#1a1a1a] via-[#2a2a2a] to-[#1a1a1a]",
  ctaContent: "relative z-10 text-center max-w-4xl mx-auto",
  ctaTitle: "text-3xl md:text-5xl lg:text-6xl font-black text-white mb-6 leading-tight",
  ctaDescription: "text-xl text-gray-300 mb-12 max-w-2xl mx-auto leading-relaxed",
  ctaButton: "px-12 py-5 bg-gradient-to-r from-[#D9782C] to-[#f59e0b] text-white font-bold rounded-2xl hover:shadow-2xl hover:shadow-orange-500/50 transition-all duration-500 transform hover:scale-105 text-lg inline-block",

  // Stats Section
  statsSection: "py-20 lg:py-32 bg-white",
  statsGrid: "grid grid-cols-2 lg:grid-cols-4 gap-8 lg:gap-12",
  statItem: "text-center",
  statNumber: "text-4xl md:text-6xl font-black bg-gradient-to-r from-[#D9782C] to-[#f59e0b] bg-clip-text text-transparent mb-2",
  statLabel: "text-gray-600 font-medium text-lg"
};